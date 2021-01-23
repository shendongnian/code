    interface IDrawer 
    {
        void Draw();
    }
    class WeaponDrawer : IDrawer // class carries out the drawing of a weapon
    
    class Weapon : IDrawer
    {
        private IDrawer : weaponDrawer = new WeaponDrawer();
        // Delegate the draw method to a completely different class.
        public void Draw()
        {
            this.weaponDrawer.Draw();
        }
    }
