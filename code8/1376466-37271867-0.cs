     var data = new vehicles()
            {
                vehID = 1,
                vehDescription = "Average Car",
                vehValCriteria = new List<stepsList>()
                {
                    new stepsList()
                    {
                        steps = "Move car",
                        stepChannelsCriteria = new List<movChannels>()
                        {
                            new movChannels()
                            {
                                name = "engage firstgear",
                                criteria = new List<criterias>()
                                {
                                    new criterias()
                                    {
                                        values = 1,
                                        time = 1
                                    },
                                }
                            },
                            new movChannels()
                            {
                                name = "reach 10kph",
                                criteria = new List<criterias>()
                                {
                                    new criterias()
                                    {
                                        values = 10,
                                        time = 5
                                    },
                                }
                            },
                            new movChannels()
                            {
                                name = "maintain 10kph",
                                criteria = new List<criterias>()
                                {
                                    new criterias()
                                    {
                                        values = 10,
                                        time = 12
                                    },
                                }
                            }
                        }
                    },
                    new stepsList()
                    {
                        steps = "stop car",
                        stepChannelsCriteria = new List<movChannels>()
                        {
                            new movChannels()
                            {
                                name = "reach okph",
                                criteria = new List<criterias>()
                                {
                                    new criterias()
                                    {
                                        values = 10,
                                        time = 4
                                    },
                                }
                            },
                            new movChannels()
                            {
                                name = "put in neutral",
                                criteria = new List<criterias>()
                                {
                                    new criterias()
                                    {
                                        values = 0,
                                        time = 1
                                    },
                                }
                            },
                            new movChannels()
                            {
                                name = "turn off vehicle",
                                criteria = new List<criterias>()
                                {
                                    new criterias()
                                    {
                                        values = 0,
                                        time = 0
                                    },
                                }
                            }
                        }
                    }
                }
            };
