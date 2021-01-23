	using System;
	using Microsoft.Xna.Framework.Graphics;
	using Microsoft.Xna.Framework;
	namespace F.U.N
	{
		public class SplashScreen
		{
			public enum Status
			{
				Ready,
				FadingIn,
				Waiting,
				FadingOut,
				NotReady
			}
			private Status currentStatus;
			public Status CurrentStatus { get { return currentStatus; } }
			private Texture2D image;
			private Color color;
			private byte fade;
			private float timer,
				fadeInTime,
				waitTime,
				fadeOutTime;
			private float startToWaitTime { get { return fadeInTime; } }
			private float startToFadeOutTime { get { return fadeInTime + waitTime; } }
			private float startToEndTime { get { return fadeInTime + waitTime + fadeOutTime; } }
			public SplashScreen(Texture2D image, float fadeInTime, float waitTime, float fadeOutTime)
			{
				float min = 0.1f;
				this.image = image;
				this.fadeInTime = Math.Max(fadeInTime, min);
				this.waitTime = Math.Max(waitTime, min);
				this.fadeOutTime = Math.Max(fadeOutTime, min);
				Prepare();
			}
			public void Prepare()
			{
				fade = 0;
				timer = 0;
				color = new Color(fade, fade, fade);
				currentStatus = Status.Ready;
			}
			public void Update(GameTime gt)
			{
				//CALCULATE ALPHA & status
				if (timer < startToWaitTime)
				{
					fade = (byte)((byte.MaxValue * timer) / startToWaitTime);
					if (currentStatus != Status.FadingIn) currentStatus = Status.FadingIn;
				}
				else if (timer < startToFadeOutTime)
				{
					if (color.A < byte.MaxValue) color.A = byte.MaxValue;
					if (currentStatus != Status.Waiting) currentStatus = Status.Waiting;
				}
				else if (timer < startToEndTime)
				{
					fade = (byte)(byte.MaxValue - ((byte.MaxValue * (timer - startToFadeOutTime)) / fadeOutTime));
					if (currentStatus != Status.FadingOut) currentStatus = Status.FadingOut;
				}
				else
				{
					fade = byte.MinValue;
					if (currentStatus != Status.NotReady) currentStatus = Status.NotReady;
				}
				//UPDATE COLOR AND TIME
				color = new Color(fade, fade, fade);
				timer += (float)gt.ElapsedGameTime.TotalSeconds;
			}
			public void Draw(SpriteBatch sp)
			{
				sp.Draw(image, new Vector2(), color);
			}
			public void End()
			{
				currentStatus = Status.NotReady;
			}
		}
	}
