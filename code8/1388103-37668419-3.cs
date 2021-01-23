		void Update()
		{
			if (!m_Dragging)
			{
				return;
			}
            if(isTouchPadCoordinatorInitialized)
            {
                touchPadCoordinator.UpdateSwipe();
            }
       // The rest of the update function goes here
