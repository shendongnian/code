            // creates the CloudWatch client
            var cw = Amazon.AWSClientFactory.CreateAmazonCloudWatchClient(Amazon.RegionEndpoint.EUWest1);
            // initialses the list metrics request
            ListMetricsRequest lmr = new ListMetricsRequest();
            ListMetricsResponse lmresponse = cw.ListMetrics(lmr);
            foreach (Metric metric in lmresponse.Metrics)
            {
                // do something with
                // metric.MetricName;
                // metric.Dimensions;
                // etc
            }
