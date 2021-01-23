        private void InstallNewImage(Image value,
                                     ImageInstallationType installationType)
        {
            StopAnimate();
            this.image = value;
            
            LayoutTransaction.DoLayoutIf(AutoSize, this, this, PropertyNames.Image); 
            
            Animate();
            if (installationType != ImageInstallationType.ErrorOrInitial)
            {
                AdjustSize();
            }
            this.imageInstallationType = installationType;
            
            Invalidate();
            CommonProperties.xClearPreferredSizeCache(this);
        }
