                if (itemIds.Count() > 0)
            {                
               ServiceResponseCollection<MoveCopyItemResponse> Responses =  service.MoveItems(itemIds, folder5.Id);
                Int32 Success = 0;
                Int32 Error = 0;
                foreach (MoveCopyItemResponse respItem in Responses) {
                    switch (respItem.Result) {
                        case ServiceResult.Success: Success++;
                            break;
                        case ServiceResult.Error: Error++;
                            Console.WriteLine("Error with Item " + respItem.ErrorMessage);
                            break;
                    }                  
               }
                Console.WriteLine("Results Processed " + itemIds.Count + " Success " + Success + " Failed " + Error);
            }
