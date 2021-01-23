        System.Drawing.Imaging.ColorMatrix m_colorMatrix;
        private void Init()
        {
            // create the negative color matrix
            m_colorMatrix = new System.Drawing.Imaging.ColorMatrix(new float[][] {
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
            });
        }
