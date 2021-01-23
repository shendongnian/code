    [TestMethod]
            public void GetNotificationsByCustomerAndId_ArrayOverload_Should_Match_InputParameter_name()
            {
                string[] _testName = new string[] { _testCustomer, _testCustomerBis };
    
                // ASSUMING _testNotificationIDBis IS STRING ARRAY
                List<string> nParams = _testName.Select(n => string.Format("lastNotificationID={0}", n)).ToList<string>();
                string Url = string.Format(
                   "http://www.testpincopallo.it/Notifications/GetByCustomerAndLastID/customersNotificationsInfos?name={0}&name={1}&{2}",
                   _testName[0], _testName[1],
                   String.Join("&", nParams.ToArray()));
    
                IHttpRouteData routeData = GetRouteData(Url);
                routeData.Values["name"].Should().Be(_testName);
            }
