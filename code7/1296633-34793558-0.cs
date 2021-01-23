    private static void RemoveRowsDuplicated(Meeting model)
            {
                if (model.Attendees != null)
                {
                    var duplicates = new List<Attendees>();
                    foreach (var item in model.Attendees.GroupBy(x => x.UserName).Where(x=>x.Count()>1))
                    {
                        duplicates.AddRange(item.Skip(1));
                    }
                    duplicates.ForEach(x=>context.Attendees.Remove(x));
                }
            }
