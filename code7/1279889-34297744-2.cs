    myList.AddRange(oGal.AddressEntries.Cast<Outlook.AddressEntry>()
          .Where( x => x.Name.Contains("#").Select(
              x => new ListDetails
              {
                  Id = val,
                  Name = x.Name
              })));
