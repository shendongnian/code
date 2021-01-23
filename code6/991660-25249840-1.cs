    public class ProtocolManager
    {
        public event Action<Command> ResponseReceived;
            
        // This will read the XML definition of your protocol into a Protocol object
        public Protocol BuildProtocol()
        {
            var protocol = new Protocol
            {
                Commands = new List<Command>()
            };
    
            var xmlFile = new XmlDocument();
            xmlFile.Load(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Protocol.xml"));
    
            var protocolElement = xmlFile["protocol"];
            
            foreach (XmlNode command in protocolElement.ChildNodes)
            {
                // Load the command definition
                var comm =
                    new Command
                    {
                        Name = command.Attributes["name"].Value,
                        Value = int.Parse(command.Attributes["value"].Value),
                        Parameters = new List<Parameter>(),
                        Results = new List<Result>()
                    };
    
                // Load the list of parameters
                foreach (XmlNode p in command.SelectSingleNode("parameters").ChildNodes)
                {
                    comm.Parameters.Add(
                        new Parameter
                        {
                            Name = p.Attributes["name"].Value,
                            ParamType = Type.GetType(p.Attributes["type"].Value)
                        });
                }
    
                // Load the list of expected results
                foreach (XmlNode p in command.SelectSingleNode("results").ChildNodes)
                {
                    comm.Parameters.Add(
                        new Parameter
                        {
                            Name = p.Attributes["name"].Value,
                            ParamType = Type.GetType(p.Attributes["type"].Value)
                        });
                }
                protocol.Commands.Add(comm);
            }
    
            // You should now have a complete protocol which you can bind to UI controls
            // such as dropdown lists, and be able to parse
            return protocol;
        }
    
        // This will test the incoming stream for responses (packets)
        public void TestProtocol(SerialPort port, Protocol p)
        {
            int bytesRead = 0;
            var buffer = new byte[1024];
            do
            {
                Thread.Sleep(50); // Give the port 50ms to receive a full response
                bytesRead = port.Read(buffer, 0, buffer.Length);
    
                // For the sake of simplicity assume we read the whole packet in a single read and we don't 
                // need to look for message encapsulation (STX, ETX).
                var commandValue = buffer[0];
                var command = p.Commands.SingleOrDefault(c => c.Value == commandValue);
                if (command == null)
                {
                    throw new NotSupportedException(
                        String.Format("Unknown command received {0}", commandValue));
                }
                // Read result parameters
                int index = 1;
                foreach (var r in command.Results)
                {
                    // Here you need to implement every data type you are expecting to receive
                    // I have done 2
                    switch (r.ResultType.Name)
                    {
                        case "Byte":
                            r.Value = buffer[index];
                            index++; // Reading only a single byte
                            break;
                        case "Short":
                            r.Value = (float)(buffer[index] >> 8 | buffer[index]);
                            index += 2; // Reading a 16bit short is 2 bytes
                            break;
                        default:
                            throw new NotSupportedException(
                                String.Format("Unknown response type {0}", r.ResultType.Name));
                    }
                }
    
                // Notify listening client that we received a message response
                // and it will contain the response parameters with values
                var evt = ResponseReceived;
                if (evt != null)
                {
                    evt(command);
                }
    
            } while (bytesRead > 0);
    
            // End of read / wait for next command to be sent
        }
    }
    
    // Represents your serial protocol as a list of support commands 
    // with request/response parameters
    public  class Protocol
    {
        public List<Command> Commands { get; set; }
    
        // Used to data-bind to comboboxes etc.
        public List<string> GetCommandNames()
        {
            return Commands.Select(c => c.Name).OrderBy(c => c).ToList();
        }
    }
    
    // A single command with a name, value and list of request/response parameters
    public class Command
    {
        public string Name { get; set; }
        public int Value { get; set; }
    
        public List<Parameter> Parameters { get; set; }
        public List<Result> Results { get; set; }
    }
    
    public class Parameter
    {
        public string Name { get; set; }
        public Type ParamType { get; set; }
        public object Value { get; set; }
    }
    
    public class Result
    {
        public string Name { get; set; }
        public Type ResultType { get; set; }
        public object Value { get; set; }
    }
