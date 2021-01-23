    class RemoteControl
    {        
        public char[] brokenButtons = new char[4] {'2','5','8','9'};
        public char[] availableButtons = new char[6] { '0', '1', '3', '4', '6', '7'};        
        public char[] allButtons = new char[10] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        
        private char[] HighestPriorChannel(char[] inputChannel)
        {
            char[] channel = inputChannel.ToArray();            
            
            int pos;
            bool changed, isMarked = false;
            for (int i = channel.Length - 1; i >= 0; i--)
            {
                changed = false;
                pos = Array.IndexOf<char>(allButtons, channel[i]);
                if (isMarked) pos--;
                while (pos >= 0)
                {
                    channel[i] = allButtons[pos];
                    pos--;
                    if (!brokenButtons.Contains(channel[i])) break;
                    else changed = true;
                }
                if (isMarked || changed)
                {
                    for (int j = i + 1; j < channel.Length; j++)
                        channel[j] = availableButtons.Last();
                }
                isMarked = brokenButtons.Contains(channel[i]);
            }            
            return channel;
        }
        private char[] LowestNextChannel(char[] inputChannel)
        {
            char[] channel = inputChannel.ToArray();         
            int pos;
            bool changed, isMarked = false;
            for (int i = channel.Length - 1; i >= 0; i--)
            {
                changed = false;
                pos = Array.IndexOf<char>(allButtons, channel[i]);
                if (isMarked) pos++;
                while(pos < allButtons.Length)
                {
                    channel[i] = allButtons[pos];
                    pos++;
                    if (!brokenButtons.Contains(channel[i])) break;
                    else changed = true;
                }
                if (isMarked || changed)
                {
                    for (int j = i + 1; j < channel.Length; j++)
                        channel[j] = availableButtons.First();
                }
                isMarked = brokenButtons.Contains(channel[i]);
            }            
            return channel;
        }
        private int FindNearestChannel(char[] channel)
        {
            char[] prior = HighestPriorChannel(channel);
            char[] next = LowestNextChannel(channel);
            int intChannel = Convert.ToInt32(new string(channel));
            int intPrior = Convert.ToInt32(new string(prior));
            int intNext = Convert.ToInt32(new string(next));
            bool nextInRange = IsChannelInRange(intNext);
            bool priorInRange = IsChannelInRange(intPrior);
            if (nextInRange && priorInRange)
            {
                if ((intChannel - intPrior) > (intNext - intChannel))
                {
                    return intNext;
                }
                else
                {
                    return intPrior;
                }
            }
            else if (nextInRange)
            {
                return intNext;
            }
            else
            {
                return intPrior;
            }
        }
        private void GoBackward(int desiredChannel, int nearestChannel)
        {
            int times = 0;
            while (desiredChannel != nearestChannel)
            {
                nearestChannel--;
                times++;
            }
            Console.WriteLine("Press button (-) {0} times", times);
        }
        private void GoForward(int desiredChannel, int nearestChannel)
        {
            int times = 0;
            while(desiredChannel != nearestChannel){
                nearestChannel++;
                times++;
                
            }
            Console.WriteLine("Press button (+) {0} times", times);
        }
        public void FindChannel(string channel)
        {
            if (channel.Intersect(brokenButtons).Count() > 0)
            {                
                int nearestChannel = FindNearestChannel(channel.ToArray());
                
                Console.WriteLine("Turn Channel {0}", nearestChannel);
                int asInt = Convert.ToInt32(channel);
                if (asInt > nearestChannel)
                    GoForward(asInt, nearestChannel);
                else
                    GoBackward(asInt, nearestChannel);
            }
            else
            {
                Console.WriteLine("Turn Channel {0}", channel);
                Console.WriteLine("Done.");
            }
        }        
        private bool IsChannelInRange(int channel)
        {
            return (channel < 451) && (channel >= 0);
        }
        public bool IsValidInput(string input)
        {            
            int asInt = 0;
            return Int32.TryParse(input, out asInt) && IsChannelInRange(asInt);
        }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl rm = new RemoteControl();
            string input = "";
            bool turnOff = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter a valid channel or \"off\" to turn off");
                input = Console.ReadLine();
                turnOff = input.ToLower() == "off";
            }
            while (!(turnOff || rm.IsValidInput(input)));
            if (!turnOff)
            {
                string formatted;
                switch (input.Length)
                {
                    case 1: formatted = "00" + input; break;
                    case 2: formatted = "0" + input; break;
                    default: formatted = input; break;
                }
                rm.FindChannel(formatted);
                Console.ReadLine();
            }
        }
    }
