        /// <summary>
        /// Configures the pipeline to use the optimal resolutions for VS based on the settings currently in use
        /// </summary>
        /// <returns></returns>
        private async Task SetUpVideoStabilizationRecommendationAsync()
        {
            Debug.WriteLine("Setting up VS recommendation...");
            // Get the recommendation from the effect based on our current input and output configuration
            var recommendation = _videoStabilizationEffect.GetRecommendedStreamConfiguration(_mediaCapture.VideoDeviceController, _encodingProfile.Video);
            // Handle the recommendation for the input into the effect, which can contain a larger resolution than currently configured, so cropping is minimized
            if (recommendation.InputProperties != null)
            {
                // Back up the current input properties from before VS was activated
                _inputPropertiesBackup = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoRecord) as VideoEncodingProperties;
                // Set the recommendation from the effect (a resolution higher than the current one to allow for cropping) on the input
                await _mediaCapture.VideoDeviceController.SetMediaStreamPropertiesAsync(MediaStreamType.VideoRecord, recommendation.InputProperties);
                Debug.WriteLine("VS recommendation for the MediaStreamProperties (input) has been applied");
            }
            // Handle the recommendations for the output from the effect
            if (recommendation.OutputProperties != null)
            {
                // Back up the current output properties from before VS was activated
                _outputPropertiesBackup = _encodingProfile.Video;
                // Apply the recommended encoding profile for the output, which will result in a video with the same dimensions as configured
                // before VideoStabilization was added if an appropriate padded capture resolution was available. Otherwise, it will be slightly
                // smaller (due to cropping). This prevents upscaling back to the original size, which can result in a loss of quality
                _encodingProfile.Video = recommendation.OutputProperties;
                Debug.WriteLine("VS recommendation for the MediaEncodingProfile (output) has been applied");
            }
        }
