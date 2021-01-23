            /// <summary>
            /// Skip track and update UVC via SMTC
            /// </summary>
            private void SkipToPrevious()
            {
                smtc.PlaybackStatus = MediaPlaybackStatus.Changing;
                playbackList.CurrentItem.Source.Reset();
                playbackList.MovePrevious();
                
            }
