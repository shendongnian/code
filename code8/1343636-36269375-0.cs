    public class PaymentDTOConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(PaymentDTO).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var obj = JObject.Load(reader);
            var payment = (PaymentDTO)existingValue ?? new PaymentDTO();
            // Extract the transactions.
            var transactions = obj.Property("transactions") ?? obj.Property("Transactions");
            if (transactions != null)
                transactions.Remove();
            // Populate the remaining regular properties.
            using (var subReader = obj.CreateReader())
                serializer.Populate(subReader, payment);
            if (transactions != null)
            {
                // Deserialize the transactions list.
                var type = PaymentDTO.GetTransactionDTOType(payment.type) ?? typeof(TransactionDTO);
                using (var subReader = transactions.Value.CreateReader())
                    // Here we are taking advantage of array covariance.
                    payment.Transactions = (IEnumerable<TransactionDTO>)serializer.Deserialize(subReader, type.MakeArrayType());
            }
            return payment;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
