                    var x = new WORK
                    {
                        WORKID = new List<WORKID>
                        {
                            new WORKID
                            {
                                APPOINTMENT = "A",
                                SERVICEORDERNO = "!",
                                TECH = ".Net"
                            },
                            new WORKID
                            {
                                APPOINTMENT = "A",
                                SERVICEORDERNO = "!",
                                TECH = ".Net"
                            }
                        }
                    };
    
                    var xs = new XmlSerializer(typeof(WORK));
                    using (var sw = new StreamWriter("c:\\path\\x.xml"))
                    {
                        xs.Serialize(sw, x);
                    }
