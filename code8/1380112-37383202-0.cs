                gcmBroker.QueueNotification(new GcmNotification
                {
                    RegistrationIds = new List<string>
                    {
                        token
                    },
                    Notification = JObject.Parse("{ \"title\" : \"" + message.PatientFirstName + " " + message.PatientLastName + ". " + message.GlucoseMeasurement.TrendArrow + "\"," +
                                         " \"body\" : \"" + message.GlucoseMeasurement.ValueInMgPerDl + " at " + message.GlucoseMeasurement.Timestamp + "\"," +
                                         " \"icon\" : \"icon\"," +
                                         " \"color\" : \"#FF4081\"}")
                });
