                if (entity.Type == "builtin.datetimeV2.daterange")
                {
                    var resolutionValues = (IList<object>)entity.Resolution["values"];
                    foreach (var value in resolutionValues)
                    {
                        _start = Convert.ToDateTime(((IDictionary<string, object>)value)["start"]);
                        _end = Convert.ToDateTime(((IDictionary<string, object>)value)["end"]);
                    }
                }
                else if (entity.Type == "builtin.datetimeV2.date")
                {
                    var resolutionValues = (IList<object>)entity.Resolution["values"];
                    foreach (var value in resolutionValues)
                    {
                        _when = Convert.ToDateTime(((IDictionary<string, object>)value)["value"]);
                    }
                }
