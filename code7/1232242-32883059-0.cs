     [TestMethod]
            public void MeasurementWriteReadDelete()
            {
                Measurement core = new Measurement();
    
                DbRepository database = null;
    
                
    
                ForceTravelCharacteristicVal = new LineSeries();
                ForceTravelCharacteristicVal.Points.Add(new DataPoint(3, 3));
               
    
                database = DbRepository.GetInstance();
                database.EstablishConnection("postgres", "1234");
                Assert.IsTrue(database.IsConnected);
    
                core.Title = "aaa";
                core.Description = "bbb";
                core.Tester = "1.22";
                core.ForceTravelCharacteristic.Points.Add(new DataPoint(3, 3));
                core.ForceTravelCharacteristic.Points.Add(new DataPoint(1, 5));
                core.ForceTravelCharacteristic.Points.Add(new DataPoint(100, -100));
                core.PullForceCharacteristic.Points.Add(new DataPoint(0, 4));
                core.ReturnSpeedCharacteristic.Points.Add(new DataPoint(1, 1));
                core.EngagementPoint.X = 10;
                core.EngagementPoint.Y = 13;
    
                core.CreateInDatabase(DbRepository.GetInstance());
    
                core.Id = Convert.ToInt32(core.CurrentID);
                core.ReadCharacteristicFromDatabase(DbRepository.GetInstance());
                core.ReadMetadataFromDatabase(DbRepository.GetInstance());
                
                Assert.AreEqual("aaa", core.Title);
                Assert.AreEqual("bbb", core.Description);
                Assert.AreEqual("1.22", core.Tester);
                Assert.AreEqual(10, core.EngagementPoint.X);
                Assert.AreEqual(13, core.EngagementPoint.Y);
                Assert.AreEqual(ForceTravelCharacteristicVal.Points.ElementAt(0).X, core.ForceTravelCharacteristic.Points.ElementAt(0).X);
                Assert.AreEqual(ForceTravelCharacteristicVal.Points.ElementAt(0).Y, core.ForceTravelCharacteristic.Points.ElementAt(0).Y);
    
    
                core.DeleteFromDatabase(DbRepository.GetInstance());
            }
    
            public LineSeries ForceTravelCharacteristicVal { get; set; }
    
        }
