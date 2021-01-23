            var result = this.connection.ReadStreamEventsForwardAsync(this.stream + "/" + aggregateId, 0, 4095, false).Result;
            
            foreach (var data in result.Events)
            {
                var assemblyQualifiedName = data.Event.Metadata.ParseJson<string>();
                var type = Type.GetType(assemblyQualifiedName);
                var json = Helper.UTF8NoBom.GetString(data.Event.Data);
                var @event = JsonConvert.DeserializeObject(json, type) as Event;
                if (@event != null)
                {
                    events.Add(@event);
                }
            }
