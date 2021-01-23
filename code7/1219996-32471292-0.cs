            public bool AddSpeaker(Entities.Speaker speaker, string[] selectedCertifications)
        {
            if (selectedCertifications != null)
            {
                SpeakerCertification speakerCertification = new SpeakerCertification();
                speaker.Certifications = new List<SpeakerCertification>();
                foreach (var certificate in selectedCertifications)
                {
                    if (certificate.CompareTo("false")!=0)
                    {
                        var certificationToAdd = _ctx.Certifications.Find(int.Parse(certificate));
                        speakerCertification = new SpeakerCertification();
                        speakerCertification.CertificationId = certificationToAdd.Id;
                        speaker.Certifications.Add(speakerCertification);
                    }
                }
            }
            
            _ctx.Speakers.Add(speaker);
            _ctx.SaveChanges();
            return true;
        }
