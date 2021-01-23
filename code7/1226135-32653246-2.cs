    void BingMap_MouseWheel(object sender, MouseWheelEventArgs e)
      {
         e.Handled = true;
         System.Reflection.MethodInfo dynMethod = this.BingMap.GetType().GetMethod("ZoomAboutViewportPoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         dynMethod.Invoke(this.BingMap, new object[] { (((double)e.Delta) / 400d), e.GetPosition(this.BingMap) });
         
      }
