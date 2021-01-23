            Queue<FireBulletDelegate> bulletQueue = new Queue<FireBulletDelegate>();
            delegate void FireBulletDelegate();
    
            DispatcherTimer bulletQueueChecker;
            const int threshold = 100;
    
            private void fireButton_Click(object sender, RoutedEventArgs e)
            {
                if (bulletQueue.Count > threshold) return;
    
                FireBulletDelegate d = new FireBulletDelegate(spawnAndFireBullet);
                bulletQueue.Enqueue(d);
    
                if (bulletQueueChecker == null)
                {
                    bulletQueueChecker = new DispatcherTimer(
                                    TimeSpan.FromSeconds(0.2),
                                    DispatcherPriority.Render,
                                    (s1, e1) =>
                                    {
                                        if (bulletQueue.Count > 0)
                                            (bulletQueue.Dequeue())();
                                        //spawnAndFireBullet();
                                    },
                                    fireButton.Dispatcher);
                }
                else if (!bulletQueueChecker.IsEnabled)
                {
                    bulletQueueChecker.Start();
                }
            }
