    using System;
    using System.Diagnostics;
    using System.Xml;
    namespace XMLNet
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Executing cmd... ");
                using (Process _cmd = new Process())
                {
                    _cmd.StartInfo.FileName = "cmd.exe";
                    _cmd.StartInfo.Arguments = "/c Net View /all";
                    _cmd.StartInfo.CreateNoWindow = true;
                    _cmd.StartInfo.UseShellExecute = false;
                    _cmd.StartInfo.RedirectStandardOutput = true;
                    _cmd.Start();
                    using (XmlTextWriter _writer = new XmlTextWriter("net_view.xml", System.Text.Encoding.UTF8))
                    {
                        int _id = 0;
                        _writer.WriteStartDocument(true);
                        _writer.Formatting = Formatting.Indented;
                        _writer.Indentation = 2;
                        _writer.WriteStartElement("Net_View");
                        while (!_cmd.StandardOutput.EndOfStream)
                        {
                            string _line = _cmd.StandardOutput.ReadLine();
                            if (_line == "There are no entries in the list.")
                                return;
                            if (!String.IsNullOrWhiteSpace(_line))
                            {
                                if (_line.StartsWith(@"\\"))
                                {
                                    string _aux = _line.TrimStart('\\').TrimEnd();
                                    _writer.WriteStartElement("result");
                                    _writer.WriteAttributeString("id", _id.ToString());
                                    _writer.WriteString(_aux);
                                    _writer.WriteEndElement();
                                    _id++;
                                }
                            }
                        }
                        _writer.WriteEndElement();
                        _writer.WriteEndDocument();
                        _writer.Close();
                    }
                }
                Console.WriteLine("Done!");
            }
        }
    }
