            MetricDefinitionListResponse wsMetricListResponse = _metricsClient.MetricDefinitions.List(website.WebsiteResourceId, null, null);
            website.MetricDefinitionsList = wsMetricListResponse.MetricDefinitionCollection;
            website.MetricNamesList = new List<string>();
            foreach (var metric in website.MetricDefinitionsList.Value)
            {
                website.MetricNamesList.Add(metric.Name);
            }
            MetricValueListResponse wsValueResponse = _metricsClient.MetricValues.List(website.WebsiteResourceId, website.MetricNamesList, "",
                _timeGrain, _startDateTime, _endDateTime);
            website.MetricValueList = wsValueResponse.MetricValueSetCollection;
        }
