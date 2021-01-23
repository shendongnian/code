            Moment body = new Moment();
            ItemScope itemScope = new ItemScope();
            itemScope.Id = "replacewithuniqueforaddtarget";
            itemScope.Image = "http://www.google.com/s2/static/images/GoogleyEyes.png";
            itemScope.Type = "";
            itemScope.Description = "The description for the action";
            itemScope.Name = "An example of add activity";
            body.Object = itemScope;
            body.Type = "http://schema.org/AddAction";
            MomentsResource.InsertRequest insert =
                new MomentsResource.InsertRequest(
                    service,
                    body,
                    "me",
                    MomentsResource.InsertRequest.CollectionEnum.Vault);
            Moment wrote = insert.Execute();
            Console.WriteLine("Wrote app activity:\n" + wrote.Result);
