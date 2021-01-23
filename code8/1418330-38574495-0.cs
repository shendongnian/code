      var positions = Enumerable.Range(0, 11).OrderBy(a => Guid.NewGuid()).ToList();
      // Associate image/tones
                imageToneData = game.GameImages.Shuffle()
                    .Join(game.GameTones, gi => gi.GameId, gt => gt.GameId, (gi, gt) => new ImageToneData
                    {
                        Image = new ImageData()
                        {
                            ImageFileName = gi.Image.ImageFileName,
                            ImageId = gi.ImageId
                        },
                        Tone = new ToneData()
                        {
                            ToneFileName = gt.Tone.ToneFileName,
                            ToneId = gt.ToneId
                        },
                        Position = positions.First()
                    });
