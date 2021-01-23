        public WriteableBitmap ImageWebcam
        {
            get
            {
                return this.imageWebcam;
            }
            set
            {
                this.imageWebcam = value;
                this.NotifyOfPropertyChange(() => this.ImageWebcam);
            }
        }
