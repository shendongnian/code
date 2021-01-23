        public ActionResult RegistrationComp(NewRegistration data, bool captchaValid)
        {
            try
            {
                captchaValid = MvcCaptcha.Validate(data.CaptchaID, data.CaptchaCode, data.CurrentInstanceID);
                MvcCaptcha.ResetCaptcha(data.CaptchaID);
                if (!captchaValid)
                    return this.Json("false");
                else
                    return this.Json("true");
            }
            catch (Exception ex)
            {
                return this.Json("false");
            }
        }
