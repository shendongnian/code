            // Act
            IHttpActionResult actionResult = controller.GetChartData(quality, cars, year);
            //Notice I use YourClass instead of object here.
            var contentResult = actionResult as OkNegotiatedContentResult<YourClass>;
    
            // Assert
            Assert.IsNotNull(contentResult);   
            Assert.IsNotNull(contentResult.Content);   
            //Assert all properties of contentResult.Content like categories, series,..
