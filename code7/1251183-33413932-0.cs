           delta = 1; // 0 for zoom out
            var transform = canvas.RenderTransform as MatrixTransform;
            var matrix = transform.Matrix;
            var scale = delta >= 0 ? 1.1 : (1.0 / 1.1); // choose appropriate scaling factor
            if (dt == null)
            {
                dt = new System.Data.DataTable();
                dt.Columns.Add("Delta", typeof(double));
                dt.Columns.Add("X", typeof(double));
                dt.Columns.Add("Y", typeof(double));
            }
            dt.Rows.Add(scale, position.X, position.Y);
            matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
            transform.Matrix = matrix;
