            // Prepare DTO to delta
            var mergeDict = DeltaExtensions.MergeDictionary(
                sourceIEnum,        //Source
                destinationIEnum,   //Destination
                s => s.SomeIdKey,
                d => d.SomeIdKey);
            // Get the delta between the two
            var mergeDelta = DeltaExtensions.GetMergeDelta(mergeDict);
            
            // You now have the delta of the two:
            mergeDelta.InsertedOnly
            mergeDelta.DeletedOnly
            mergeDelta.Inserted
            mergeDelta.Updated
            mergeDelta.Deleted
