     public Program()
            {
                using (var client = new WebClient())
                {
                    string str = client.DownloadString("https://api.pinterest.com/v3/pidgets/boards/Monokumagirl/anime-girls/pins/");
                    JObject jobject = JObject.Parse(str);
                    JToken pins = jobject["data"]["pins"];
                    int i = 0;
                    while(true)
                    {
                        try {
                            var pin = pins[i];
                            Console.WriteLine(pin["images"]["237x"]["url"]);
                            i++;
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                    }
                    Console.WriteLine("count: " + i);
                }
                Console.ReadLine();
            }
