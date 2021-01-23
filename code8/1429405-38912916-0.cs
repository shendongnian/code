    var query = from booking in context.BookingTables
                        join transport in context.TransportAllotments on booking.TransportAllotmentID equals transport.TransportAllotmentID
                        join passenger in context.Passengers on booking.BookingID equals passenger.BookingID
                        join result in context.QuestionaireResults on passenger.PassengerID equals result.PassengerID
                        join question in context.QuestionaireQuestions on result.QuestionaireQuestionID equals question.QuestionaireQuestionID
                        where transport.DepartureDate >= startDate && transport.DepartureDate <= endDate && booking.BookingID == id
                        .AsEnumerable()
                        select new QuestionaireDetailsDTO()
                        {
                            ID = booking.BookingID,
                            Date = transport.DepartureDate,
                            Question = question.QuestionText,
                            Week =  GetWeekOfYear(transport.DepartureDate) 
                        };
