    private void uxRemoveMarkerButton_Click(object sender, EventArgs e)
        {
                int? mID = null;
                if(currentMarker != null)
                {
                    mID = Convert.ToInt32(currentMarker.Tag);
                    markersOverlay.Markers.Remove(currentMarker);
                    currentMarker = null;
                }
                m_dbMarkers.Delete(_table, String.Format("markers.ID = {0} ", mID));
                uxRemoveMarkerButton.Enabled = false;
         }
