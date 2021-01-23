                foreach(Attendee attendee in aptobj.RequiredAttendees){
                if (attendee.ResponseType.HasValue)
                {
                    Console.WriteLine(attendee.Address + " " + attendee.ResponseType.Value);
                }
            }
            foreach (Attendee attendee in aptobj.OptionalAttendees)
            {
                if (attendee.ResponseType.HasValue)
                {
                    Console.WriteLine(attendee.Address + " " + attendee.ResponseType.Value);
                }
            }
