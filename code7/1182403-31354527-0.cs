    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    namespace Brick
    {
        class Postprocessor
        {
            private Effect CurrentEffect;
            private Effect DefaultEffect;
            private bool Multipass;
    
            private RenderTarget2D FinalImage;
            private RenderTarget2D EmptyTarget;
    
            public int Passescount
            {
                get 
                {
                    return CurrentEffect.CurrentTechnique.Passes.Count;
                }
            }
    
            public Postprocessor(Effect EffectToUse, Effect StandardEffect)
            {
                if (!ChangeCurrentEffect(EffectToUse))
                    return;
                DefaultEffect = StandardEffect;
                EmptyTarget = new RenderTarget2D(DefaultEffect.GraphicsDevice, GameSettings.WindowWidth, GameSettings.WindowHeight);
            }
            public bool ChangeCurrentEffect(Effect EffectToUse)
            {
                CurrentEffect = EffectToUse;
                if (CurrentEffect.CurrentTechnique.Passes.Count > 1)
                    Multipass = true;
                else
                    Multipass = false;
                return true;
            }
    
            private bool CheckIfParameterExist(string Name)
            {
                foreach (EffectParameter parameter in CurrentEffect.Parameters)
                {
                    if (parameter.Name == Name)
                        return true;
                }
                return false;
            }
    
            public void Update(GameTime gametime, Vector2 MousePosition)
            {
                SetParameters((float)gametime.TotalGameTime.TotalSeconds, MousePosition);
            }
    
            private void SetParameters(float gametime, Vector2 MousePosition)
            {
                if (CheckIfParameterExist("GameTime"))
                    CurrentEffect.Parameters["GameTime"].SetValue(gametime);
                if (CheckIfParameterExist("MousePosition"))
                    CurrentEffect.Parameters["MousePosition"].SetValue(MousePosition);
            }
    
            public void Draw(GraphicsDevice graphics, RenderTarget2D Target, SpriteBatch SB)
            {
                if (Multipass)
                {
                    FinalImage = MultiCallPostprocess(graphics, SB, Target);
                }
                else
                {
                    FinalImage = SinglePostprocessCall(graphics, SB, Target, 0);
                }
                graphics.Clear(Color.Transparent);
                DefaultEffect.CurrentTechnique.Passes[0].Apply();
                SB.Draw(FinalImage, new Rectangle(0, 0, FinalImage.Width, FinalImage.Height), Color.White);
            }
    
            private RenderTarget2D MultiCallPostprocess(GraphicsDevice graphics, SpriteBatch SB, RenderTarget2D DrawTarget)
            {
                for (int i = 0; i < CurrentEffect.CurrentTechnique.Passes.Count; i++)
                {
                    DrawTarget = SinglePostprocessCall(graphics, SB, DrawTarget, i);
                }
                return DrawTarget;
            }
    
            private RenderTarget2D SinglePostprocessCall(GraphicsDevice graphics, SpriteBatch SB, RenderTarget2D DrawTarget, int PassPosition)
            {
                EmptyTarget.Dispose();
                EmptyTarget = new RenderTarget2D(graphics, DrawTarget.Width, DrawTarget.Height);
                if (CurrentEffect.CurrentTechnique.Passes.Count >= PassPosition)
                {
                    graphics.SetRenderTarget(EmptyTarget);
                    graphics.Clear(Color.Transparent);
                    CurrentEffect.CurrentTechnique.Passes[PassPosition].Apply();
                    SB.Draw(DrawTarget, new Rectangle(0, 0, DrawTarget.Width, DrawTarget.Height), Color.White);
                    graphics.SetRenderTarget(null);
                }
                else
                {
                    EmptyTarget = DrawTarget;
                }
                return CloneRenderTarget(EmptyTarget);
            }
            private RenderTarget2D CloneRenderTarget(RenderTarget2D target)
            {
                var clone = new RenderTarget2D(target.GraphicsDevice, target.Width,
                    target.Height, target.LevelCount > 1, target.Format,
                    target.DepthStencilFormat, target.MultiSampleCount,
                    target.RenderTargetUsage);
    
                for (int i = 0; i < target.LevelCount; i++)
                {
                    double rawMipWidth = target.Width / Math.Pow(2, i);
                    double rawMipHeight = target.Height / Math.Pow(2, i);
    
                    // make sure that mipmap dimensions are always > 0.
                    int mipWidth = (rawMipWidth < 1) ? 1 : (int)rawMipWidth;
                    int mipHeight = (rawMipHeight < 1) ? 1 : (int)rawMipHeight;
    
                    var mipData = new Color[mipWidth * mipHeight];
                    target.GetData(i, null, mipData, 0, mipData.Length);
                    clone.SetData(i, null, mipData, 0, mipData.Length);
                }
    
                return clone;
            }
    
        }
    }
