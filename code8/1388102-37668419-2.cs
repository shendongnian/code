		public void OnPointerUp(PointerEventData data)
		{
			m_Dragging = false;
			m_Id = -1;
			UpdateVirtualAxes(Vector3.zero);
            if(isTouchPadCoordinatorInitialized)
            {
                touchPadCoordinator.ClearDirectionCache();
            }
		}
