      catch (EUserAlreadyExist ex)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            resp.Content = new StringContent(string.Format("Already exist ", SU.user.Mail));
            resp.ReasonPhrase = "Already exist";
            throw new HttpResponseException(resp);
        }
