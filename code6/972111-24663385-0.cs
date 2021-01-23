        public DescribeInstancesResult GetInstances(Ec2Key ec2Key)
        {
            _logger.Debug("GetInstances Start.");
            AmazonEC2 ec2 = CreateAmazonEc2Client(ec2Key);
            var ec2Request = new DescribeInstancesRequest();
            DescribeInstancesResponse describeInstancesResponse = ec2.DescribeInstances(ec2Request);
            DescribeInstancesResult result = describeInstancesResponse.DescribeInstancesResult;
            _logger.Debug("GetInstances End.");
            return result;
        }
