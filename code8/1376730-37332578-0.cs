            var query = from i in sqlcmd.Table select i;
            if (ID.Text.Length > 0)
            {
                var personGivenByID = from person in query.AsEnumerable()
                                      where person.ID == Convert.ToDouble(ID.Text)
                                      select person;
                var sameAddressLikeGivenPerson = from row in query.AsEnumerable()
                                                 where row.State == personGivenByID.FirstOrDefault().State
                                                 && row.City == personGivenByID.FirstOrDefault().City
                                                 && row.District == personGivenByID.FirstOrDefault().District
                                                 && row.Street == personGivenByID.FirstOrDefault().Street
                                                 && row.BuildingName == personGivenByID.FirstOrDefault().BuildingName
                                                 && row.DoorNumber == personGivenByID.FirstOrDefault().DoorNumber
                                               //&& row.ID != personGivenByID.FirstOrDefault().ID
                                                 select row;
                gridview.DataSource = sameAddressLikeGivenPerson != null ? sameAddressLikeGivenPerson : sameAddressLikeGivenPerson;
            }
