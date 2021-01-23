    PlusService plus = new PlusService(
                new Google.Apis.Services.BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyDWG1Ho6PVC6FlPXv5rommyzCAf0ziHkTo"
                });
    
                ActivitiesResource ar = new ActivitiesResource(plus);
    
                ActivitiesResource.ListRequest list = ar.List(id, new ActivitiesResource.ListRequest.CollectionEnum());
    
                list.MaxResults = 100; // Or whatever number you want
    
                ActivityFeed feed = list.Execute();
