        public EnvelopeUpdateSummary VoidRequest(string envelopeId, string message)
        {
            var envelope = new Envelope()
            {
                Status = "voided",
                VoidedReason = message
            };
            var updateSummary = EnvelopesApi.Update(AccountId, envelopeId, envelope);
            return updateSummary;
        }
