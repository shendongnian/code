        public static bool IsUnprocessableEntityResponse(this HttpResponseMessage message)
        {
            Requires.NotNull(message, nameof(message));
            return (int) message.StatusCode == StatusCodes.Status422UnprocessableEntity;
        }
