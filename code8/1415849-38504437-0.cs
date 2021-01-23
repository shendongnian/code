     protected void SetChildAlongAxis(RectTransform rect, int axis, float pos, float size)
        {
            if (rect == null)
                return;
            m_Tracker.Add(this, rect,
                DrivenTransformProperties.Anchors |
                DrivenTransformProperties.AnchoredPosition |
                DrivenTransformProperties.SizeDelta);
            rect.SetInsetAndSizeFromParentEdge(axis == 0 ? RectTransform.Edge.Left : RectTransform.Edge.Top, pos, size);
        }
