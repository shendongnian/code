            string token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJpc3N1ZXIiLCJzdWIiOiJzdWJqZWN0IiwiYXVkIjoiYXVkaWVuY2UiLCJleHAiOjE0NjAwMDIxNzEsIm5iZiI6MTQ1ODI3Mzg3MSwiaWRnSWQiOiIwMDAxNzI4MTcwIiwic2Vjb25kRmEiOiJmYWxzZSIsInJvbGVzIjoiW09OTElORV9UUkFESU5HLCBST0xFX09OTElORV9UUkFESU5HLCBPTkxJTkVfVklFV19BQ0NPVU5UX0lORk8sIFJPTEVfT05MSU5FX1ZJRVdfQUNDT1VOVF9JTkZPXSIsImN1c3RvbWVySWQiOiIwMDAxNzI4MTcwIiwidnRvc0F1dGhlbnRpY2F0ZWQiOiJmYWxzZSIsInVzZXJJZCI6IjUyNzY5IiwiY3VzdG9tZXJOYW1lIjoiTmd1eWVuIFZhbiBNIiwiZW1haWwiOiJtaW5odHE5MEBnbWFpbC5jb20iLCJ1c2VybmFtZSI6InRlc3QyMiIsInN0YXR1cyI6Ik9OTElORV9BQ1RJVkUifQ.CfcVsKidaHi6QEneYDfox9509SnIQUQZS6OUWf3jBN4OnTEQ-xFeHeIuQP6qgEK3b_0fLjWZ4OT7qnItLMKYg0vd68OxjDbHw79C4jQNnxq1EUgsEs72-gNNBV42n6I0R5VZy4t6AuKgHTFp6gN4fTisfA7vnX2Vq5Sg2faAoMl2nevN7F1P9YEWFPea9qoDqmPwGY72DvEauZNZmIb7OvtRvoBFAK_cIJvuRShIzUfQ5q4W4sMiRH92Ou_6S7k4NfqO8kOdoJkSqZCDlhJIdAmyW4IBsYc5TvgeoGIrzgKCVr2_1wM0RHXE3vq6oobe2rB68Rc8eQ0VYzH6fH4KQA";
            string converted = token.Replace("-", "");
            converted = converted.Replace("_", "");
            converted = converted.Replace(".", "");
            int mod4 = converted.Length % 4;
            if (mod4 > 0)
            {
                converted += new string('=', 4 - mod4);
            }
            var bytesToDecrypt = Convert.FromBase64String(converted);
