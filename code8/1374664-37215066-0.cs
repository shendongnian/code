    public void LookRotation(Transform character, Transform camera)
    {
         float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
         float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
            m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);
            if (ORPargaModification)
            {
                if(Input.GetKeyDown(KeyCode.U))
                {
                    Debug.Log("U pressed");
                    m_CharacterTargetRot *= Quaternion.Euler(0f, 180, 0f);
                }
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }
            else
            {
                if (clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
                if (smooth)
                {
                    character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
                        smoothTime * Time.deltaTime);
                    camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
                        smoothTime * Time.deltaTime);
                }
                else
                {
                    character.localRotation = m_CharacterTargetRot;
                    camera.localRotation = m_CameraTargetRot;
                }
            }
            UpdateCursorLock();
        }
