        [HttpGet]
        public ActionResult GetVnAudioStream(int id)
        {
            if (id > 0)
            {
                var pronunciation = babbelerRepo.GetVnPronunciationById(id);
                if (pronunciation != null && pronunciation.Length > 0)
                {
                    return File(pronunciation, "audio/mp3");
                }
            }
            return null;
        }
