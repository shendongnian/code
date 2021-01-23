     <TextBlock Text="{Binding }" Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=UserControl}}">
                                <TextBlock.ContextMenu>
                                    <ContextMenu >
                                        <MenuItem Header="Enregistrer la pièce jointe" Foreground="Black">
                                            <MenuItem Header="Dans le dossier patient" Command="{Binding Path=PlacementTarget.Tag.SaveAttachmentIntPatientFolderCommand,
                                                RelativeSource={RelativeSource AncestorType=ContextMenu}}"                                                  
                                                      Foreground="Black" />
                                            <MenuItem Header="Enregistrer sous ..." Command="{Binding Path=PlacementTarget.Tag.SaveAttachmentAsCommand,
                                                RelativeSource={RelativeSource AncestorType=ContextMenu}}"  
                                                       Foreground="Black" />
                                        </MenuItem>
                                    </ContextMenu>
                                </TextBlock.ContextMenu>
                            </TextBlock>     
