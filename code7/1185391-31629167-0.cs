            _bandClient.SensorManager.HeartRate.ReadingChanged += async (obj, ev) =>
            {
                var type = obj.GetType();
                var props = type.GetRuntimeProperties().Where(p => p.Name == "ClientHandle").First();
                var bc = (IBandClient)props.GetValue(obj);
                // compare with cached band client references
                if (object.ReferenceEquals(bc, _bandClient))
                {
                }
            }
