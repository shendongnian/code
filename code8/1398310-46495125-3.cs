            private void PathfindingComplete(Vector3[] pathPoints)
        {
            if (pathPoints != null)
            {
                status = DriverStatus.Navigating;
                foreach (Vector3 x in pathPoints)
                {
                    //Debug.Log(x);
                    path.Enqueue(x);
                }
                BuildPathArrows();
            }
            calculating = false;
        }
