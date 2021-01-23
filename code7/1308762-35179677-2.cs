    static void Main(string[] args)
    {
      string case1 = @"{
         ""Items"": {
             ""Value"":1
         }
      }";
      string case2 = @"{
         ""Items"": [
            {
             ""Value"":21
            },
            {
             ""Value"":22           
            },
         ]
      }";
      string case3 = @"{
      }";
      BigObject c1 = JsonConvert.DeserializeObject<BigObject>(case1);
      Console.WriteLine("c1 value = {0}", c1.Items[0].Value);
      BigObject c2 = JsonConvert.DeserializeObject<BigObject>(case2);
      Console.WriteLine("c2 value1 = {0}", c2.Items[0].Value);
      Console.WriteLine("c2 value2 = {0}", c2.Items[1].Value);
      BigObject c3 = JsonConvert.DeserializeObject<BigObject>(case3);
      Console.WriteLine("c3 items = {0}", c3.Items == null ? "null" : "non-null" );
    }
