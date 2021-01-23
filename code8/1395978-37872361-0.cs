    var query = from record in db.Businesses
                    where record.Id == userModel.BusinessId
                    select record;
    var business = query.Include("Workers").First();
    //                   ^^^^^^^^^^^^^^^^^^
