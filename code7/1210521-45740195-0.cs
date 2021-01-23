            LoginRequest loginRequest = new LoginRequest()
            {
                Code = "UserId",
                Password = "myPass",
                CMToken = "eIFt4lYTKGU:APA91bFZPe3XCDL2r1JUJuEQLlN3FoeFw9ULpw8ljEavNdo9Lc_-Qua4w9pTqdOFLTb92Kf03vyWBqkcvbBfYEno4NQIvp21kN9sldDt40eUOdy0NgMRXf2Asjp6FhOD1Kmubx1Hq7pc",
            };
            byte[] rawBytes = ProtoBufSerializer.ProtoSerialize<LoginRequest>(loginRequest);
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            //var bSonData = HttpExtensions.SerializeBson<T>(data);
            var byteArrayContent = new ByteArrayContent(rawBytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
            var result = client.PostAsync("Api/Login", byteArrayContent).Result;
            Console.WriteLine(result.IsSuccessStatusCode);
