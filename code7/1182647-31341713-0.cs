            // Act
            IHttpActionResult actionResult = controller.GetChartData(quality, cars, year);
            var contentResult = actionResult as OkNegotiatedContentResult<object>;
    
            // Assert
            Assert.IsNotNull(contentResult);   
            //De-serialize the string to object
            YourClass m = JsonConvert.DeserializeObject<YourClass>(contentResult.Content);
     
            //Assert all properties like categories, series,..
