        public void SizeChanged()
        {
            if (!App.IsLandscape)
            {
                 ...
                 this.ActivePart = ActivePartEnum.ListOnly.ToString();
                 ...
            }
            else
            {
                 ...
                 this.ActivePart = ActivePartEnum.Both.ToString();
                 ...
            }
        }
