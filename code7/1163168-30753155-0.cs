        var qisg = new QuoteItemSectionGroup
            {
                SectionGroup = db.SectionGroups.Where(x => x.Name == "Longitudinals" && x.Section == TruckSection.Floor).First(),
                StockItem.Add('BodyType.Longitudinal',quoteItem.BodyType.Longitudinal);
                StockItem.Add('Chassis.Longitudinal',quoteItem.Chassis.Longitudinal); <<--------
                Quantity = 2,
                Length = globals.FloorCalculatedLength
            };
