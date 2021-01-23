    private void RemoveRowsDuplicated(Meeting model)
            {
                if (model.Attendees != null)
                {
                    model.Attendees=model.Attendees.Distinct()
                }
            }
