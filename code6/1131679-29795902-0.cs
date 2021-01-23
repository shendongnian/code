               StreamReader  sReader = new StreamReader("filename");
                string a = sReader.ReadToEnd();
                a.Replace("\"", "");
                a.Replace("\r\"", "");
                StringReader reader = new StringReader(a);
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                }
