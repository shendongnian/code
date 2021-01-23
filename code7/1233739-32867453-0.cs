      private void Participant_ModalityStateChanged(object sender, ModalityStateChangedEventArgs e)
        {
            if (e.NewState == ModalityState.Connected)
            {
                var modality = (AVModality) sender;
                var participant = modality.Participant;
                var uri = participant.Contact.Uri;
            }
        }
