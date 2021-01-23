     using System;
    using System.Diagnostics;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    using Windows.Media;
    using Windows.Media.Playback;
    
    namespace PLAYER
    {
        public sealed class BackgroundTask : IBackgroundTask
        {
            private string Artista { get; set; }
            private string Titolo { get; set; }
            private BackgroundTaskDeferral _deferral;
            private SystemMediaTransportControls _systemMediaTransportControl;
    
            public void Run(IBackgroundTaskInstance taskInstance)
            {
                _systemMediaTransportControl = SystemMediaTransportControls.GetForCurrentView();
                _systemMediaTransportControl.IsEnabled = true;
    
                BackgroundMediaPlayer.MessageReceivedFromForeground += MessageReceivedFromForeground;
                BackgroundMediaPlayer.Current.CurrentStateChanged += BackgroundMediaPlayerCurrentStateChanged;
    
                // Associate a cancellation and completed handlers with the background task.
                taskInstance.Canceled += OnCanceled;
                taskInstance.Task.Completed += Taskcompleted;
    
                _deferral = taskInstance.GetDeferral();
            }
    
            private void MessageReceivedFromForeground(object sender, MediaPlayerDataReceivedEventArgs e)
            {
                ValueSet valueSet = e.Data;
                foreach (string key in valueSet.Keys)
                {
                    switch (key)
                    {
                       
                        case "Title":
                            Titolo = valueSet[key].ToString();
                           
    
                            break;
                        case "Artist":
                            Artista = valueSet[key].ToString();
                     
                            break;
                        case "Play":
                            Debug.WriteLine("Starting Playback");
                            Play(valueSet[key].ToString());
                            break;
    
                     
    
                    }
                   
                }
            }
    
            private void Play(string toPlay)
            {
                MediaPlayer mediaPlayer = BackgroundMediaPlayer.Current;
                mediaPlayer.AutoPlay = true;
                mediaPlayer.SetUriSource(new Uri(toPlay));
                _systemMediaTransportControl.ButtonPressed += MediaTransportControlButtonPressed;
                _systemMediaTransportControl.IsPauseEnabled = true;
                _systemMediaTransportControl.IsPlayEnabled = true;
                _systemMediaTransportControl.IsNextEnabled = true;
                _systemMediaTransportControl.IsPreviousEnabled = true;
                _systemMediaTransportControl.DisplayUpdater.Type = MediaPlaybackType.Music;
                _systemMediaTransportControl.DisplayUpdater.MusicProperties.Artist = Artista;
                _systemMediaTransportControl.DisplayUpdater.MusicProperties.Title = Titolo;
                
                _systemMediaTransportControl.DisplayUpdater.Update();
    
            }
    
     
    
    
            /// <summary>
            ///     The MediaPlayer's state changes, update the Universal Volume Control to reflect the correct state.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            private void BackgroundMediaPlayerCurrentStateChanged(MediaPlayer sender, object args)
            {
                if (sender.CurrentState == MediaPlayerState.Playing)
                {
                    _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Playing;
                }
                else if (sender.CurrentState == MediaPlayerState.Paused)
                {
                    _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Paused;
                }
            }
    
            /// <summary>
            ///     Handle the buttons on the Universal Volume Control
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            private void MediaTransportControlButtonPressed(SystemMediaTransportControls sender,
                SystemMediaTransportControlsButtonPressedEventArgs args)
            {
                switch (args.Button)
                {
                    case SystemMediaTransportControlsButton.Play:
                        BackgroundMediaPlayer.Current.Play();
                        break;
                    case SystemMediaTransportControlsButton.Pause:
                        BackgroundMediaPlayer.Current.Pause();
                        break;
                }
            }
    
    
            private void Taskcompleted(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
            {
                BackgroundMediaPlayer.Shutdown();
                _deferral.Complete();
            }
    
            private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
            {
                // You get some time here to save your state before process and resources are reclaimed
                BackgroundMediaPlayer.Shutdown();
                _deferral.Complete();
            }
        }
    }
