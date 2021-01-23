            static void Main(string[] args)
        {
            string awsAccess = "";
            string awsSecret = "";
            string bucketName = "";
            AmazonS3Client client = new AmazonS3Client(awsAccess, awsSecret, RegionEndpoint.USWest2);
            var buckets = client.GetBucketLocation(bucketName);
            string httpResponse = buckets.HttpStatusCode.ToString();
            if (httpResponse == "OK")
            {
                Console.WriteLine("HttpStatus: Good");
            }
            else Console.WriteLine("Something went wrong");
            
            Console.ReadKey();
        }
